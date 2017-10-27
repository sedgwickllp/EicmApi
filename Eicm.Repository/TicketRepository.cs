using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using NLog;
using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Tickets;
using System.Linq;
using Eicm.Core;
using Eicm.Core.Enums;

namespace Eicm.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public TicketRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<Ticket>> GetTicketByIdAsync(int id)
        {
            try
            {
                var foundTicket = await _coreDbContext.Tickets.Include(t => t.Comments).SingleAsync(t => t.Id == id);
                return new CommonResult<Ticket>(foundTicket, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<Ticket>(null, ResultCode.Failure, ex.Message);
            }
        }
        public async Task<ICommonResult<List<Ticket>>> GetTicketsAsync()
        {
            try
            {
                var tickets = await _coreDbContext.Tickets.Include(t => t.Priority).OrderBy(c => c.CreatedDateTime).ToListAsync();
                return new CommonResult<List<Ticket>>(tickets, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<Ticket>>(null, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<List<Ticket>>> GetActiveTicketsAsync()
        {
            try
            {
                var tickets = await _coreDbContext.Tickets.Where(tic => tic.IsActive).Include(t => t.Priority).OrderBy(c => c.CreatedDateTime).ToListAsync();
                return new CommonResult<List<Ticket>>(tickets, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<Ticket>>(null, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<List<Ticket>>> GetActiveTicketsByUserIdAsync(int userId)
        {
            try
            {
                var tickets = await _coreDbContext.Tickets
                    .Where(tic => tic.IsActive && tic.OwnerId == userId)
                    .Include(t => t.Priority)
                    .OrderBy(c => c.CreatedDateTime)
                    .ToListAsync();
                return new CommonResult<List<Ticket>>(tickets, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<Ticket>>(null, ResultCode.Failure, ex.Message);
            }

        }
        //thinking business logic will get userIds for requester and owner.
        public async Task<ICommonResult<int>> AddTicketAsync(string summary, int requesterId, int? ownerId, int? causeId, 
            int statusId, int priorityId, int originId, int? categoryId, int? subcategoryId, bool isConfidential, bool isVip, int userId)
        {
            try
            {
                var ticket = new Ticket
                {
                    Summary = summary,
                    RequesterId = requesterId,
                    OwnerId = ownerId,
                    CauseId = causeId,
                    StatusId = statusId,
                    PriorityId = priorityId,
                    OriginId = originId,
                    CategoryId = categoryId,
                    SubCategoryId = subcategoryId,
                    IsConfidential = isConfidential,
                    IsVip = isVip,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now,
                    IsDeleted = false
                };

                _coreDbContext.Tickets.Add(ticket);

                var history = new TicketHistory
                {
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    TicketId = ticket.Id,
                    Summary = summary,
                    RequesterId = requesterId,
                    OwnerId = ownerId,
                    CauseId = causeId,
                    StatusId = statusId,
                    PriorityId = priorityId,
                    OriginId = originId,
                    CategoryId = categoryId,
                    SubCategoryId = subcategoryId,
                    IsConfidential = isConfidential,
                    IsVip = isVip,
                    IsDeleted = false
                };

                _coreDbContext.TicketHistories.Add(history);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(ticket.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<bool>> UpdateTicketAsync(int id, string summary, int requesterId, int ownerId, int? cause, int? statusId, 
            int? priority, int origin, int? category, int? subcategory, bool isConfidential)
        {
            try
            {
                var userId = 1;
                var ticket = await _coreDbContext.Tickets.SingleAsync(t => t.Id == id);

                //CreateTicketActivityChanges(ticket, category, cause, isConfidential, origin, priority, statusId, subcategory, userId);

                ticket.CategoryId = category;
                ticket.CauseId = cause;
                ticket.IsConfidential = isConfidential;
                ticket.OriginId = origin;
                //ticket.OwnerId = ownerId;
                ticket.PriorityId = priority ?? ticket.PriorityId;
                //ticket.RequesterId = requesterId;
                ticket.StatusId = statusId ?? ticket.StatusId;
                ticket.SubCategoryId = subcategory;
                ticket.Summary = summary;
                ticket.IsConfidential = isConfidential;
                ticket.ModifedByUserId = 1; //TODO insert userId
                ticket.ModifiedDateTime = DateTime.Now;
             

                var history = new TicketHistory
                {
                    CreatedByUserId = 1,
                    CreatedDateTime = DateTime.Now,
                    TicketId = ticket.Id,
                    Summary = summary,
                    RequesterId = requesterId,
                    OwnerId = ownerId,
                    CauseId = cause,
                    StatusId = statusId ?? ticket.StatusId,
                    PriorityId = priority ?? ticket.PriorityId,
                    OriginId = origin,
                    CategoryId = category ?? ticket.CategoryId,
                    SubCategoryId = subcategory ?? ticket.SubCategoryId,
                    IsConfidential = isConfidential,
                    IsVip = ticket.IsVip,
                    IsDeleted = false
                };

                _coreDbContext.TicketHistories.Add(history);

                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }
        }

        private void CreateTicketActivityChanges(Ticket ticket, int? category, int? cause, bool isConfidential, int origin, int? priority, int? statusId, int? subcategory, int userId)
        {
            var actList = new List<TicketActivity>();
            if (ticket.IsConfidential != isConfidential)
            {
                var act = new TicketActivity
                {
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ActivityId = ActivityType.Updated.GetHashCode(),//AttributeMethods.GetByDisplayed<ActivityType>(nameof(ticket.IsConfidential)).GetHashCode(),
                    TicketId = ticket.Id,
                    TicketPropertyId = AttributeMethods.GetByDisplayed<TicketPropertyType>(nameof(ticket.IsConfidential)).GetHashCode(),
                    FromValue = ticket.IsConfidential.ToString(),
                    ToValue = isConfidential.ToString()
                };
                actList.Add(act);
            }
            _coreDbContext.TicketActivities.AddRange(actList);
        }
        public async Task<ICommonResult<bool>> DeleteTicketAsync(int id)
        {
            try
            {
                var oldTicket = _coreDbContext.Tickets.First(t1 => t1.Id == id);
                oldTicket.IsActive = false;
                _coreDbContext.Tickets.AddOrUpdate(oldTicket);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }

        }

        public void Dispose()
        {
            _coreDbContext?.Dispose();
        }
    }
}