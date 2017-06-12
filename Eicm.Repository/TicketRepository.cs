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
                    IsActive = true
                };

                _coreDbContext.Tickets.Add(ticket);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(ticket.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<bool>> UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                _coreDbContext.Tickets.AddOrUpdate(ticket);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }
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