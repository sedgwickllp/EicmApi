using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Eicm.Core.Enums;
using Eicm.Core.Extensions;
using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Tickets;
using NLog;

namespace Eicm.Repository
{
    public class TicketCommentsRepository : ITicketCommentsRepository
    {
        private readonly ICoreDbContext _coreDbContext;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TicketCommentsRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public async Task<ICommonResult<TicketComment>> GetTicketNoteByIdAsync(int id)
        {

            try
            {
                var note = await _coreDbContext.TicketComments.FindAsync(id);
                return new CommonResult<TicketComment>(note, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return new CommonResult<TicketComment>(null, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<List<TicketComment>>> GetTicketNotesAsync()
        {
            try
            {
                var notes = await _coreDbContext.TicketComments.OrderBy(c => c.CreatedDateTime).ToListAsync();
                return new CommonResult<List<TicketComment>>(notes, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return new CommonResult<List<TicketComment>>(null, ResultCode.Failure, ex.Message);
            }
        }

        
        public async Task<ICommonResult<int>> AddTicketCommentAsync(int ticketId, string comment, bool isVisibleToAll, int userId)
        {
            try
            {
                var ticketComment = new TicketComment
                {
                    TicketId = ticketId,
                    Comment = comment,
                    IsVisibleToAll = isVisibleToAll,
                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };

                _coreDbContext.TicketComments.Add(ticketComment);

                var act = new TicketActivity
                {
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ActivityId = ActivityType.CommentAdded.GetHashCode(),
                    TicketId = ticketId
                };

                _coreDbContext.TicketActivities.Add(act);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(ticketComment.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing note.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketComment note)
        {
            try
            {
                _coreDbContext.TicketComments.AddOrUpdate(note);

                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }
        }

        /// <summary>
        /// Marks a ticket as inactive instead of doing a hard delete.
        /// </summary>
        /// <param name="id">Id of the ticket to "delete"</param>
        /// <returns>Id of the ticket "deleted"</returns>
        public async Task<ICommonResult<bool>> DeleteTicketNoteAsync(int id)
        {
            try
            {
                var oldNote = await _coreDbContext.TicketComments.FindAsync(id);
                if (oldNote == null)
                {
                    var notFoundException = new KeyNotFoundException();
                    _logger.Error(notFoundException, "Ticket with id {0} not found.", id);
                    throw notFoundException;
                }
                oldNote.IsActive = false;
                _coreDbContext.TicketComments.AddOrUpdate(oldNote);

                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure);
            }
        }

        /// <summary>
        /// Disposes the enterpiseContext if it's not null.
        /// </summary>
        public void Dispose()
        {
            _coreDbContext?.Dispose();
        }
    }
}
