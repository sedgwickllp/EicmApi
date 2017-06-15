using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class TicketCommentsBusinessLogic : ITicketCommentsBusinessLogic
    {
        private readonly ITicketCommentsRepository _ticketCommentsRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TicketCommentsBusinessLogic(ITicketCommentsRepository ticketCommentsRepository)
        {
            _ticketCommentsRepository = ticketCommentsRepository;
        }
        public async Task<ICommonResult<TicketCommentModel>> GetTicketNoteByIdAsync(int id)
        {           
            var dbnote =  await _ticketCommentsRepository.GetTicketNoteByIdAsync(id);
            if (dbnote.ResultCode && dbnote.Payload == null)
            {
                _logger.Info("No note returned for id: " + id);
                return new CommonResult<TicketCommentModel>(null, dbnote.ResultCode);
            }
            if (!dbnote.ResultCode)
            {
                _logger.Info("getTicketNoteByIdAsync returned failed from repo");
                return new CommonResult<TicketCommentModel>(null, dbnote.ResultCode, dbnote.Message);
            }
            _logger.Info("Note retrieved");
            return new CommonResult<TicketCommentModel>(new TicketCommentModel(dbnote.Payload), dbnote.ResultCode); 
        }
        
        public async Task<ICommonResult<List<TicketCommentModel>>> GetTicketNotesAsync()
        {
            var dbnoteList = await _ticketCommentsRepository.GetTicketNotesAsync();       

            if (dbnoteList.ResultCode)
            {
                var noteList = dbnoteList.Payload.Select(note => new TicketCommentModel(note)).ToList();
                return new CommonResult<List<TicketCommentModel>>(noteList, dbnoteList.ResultCode);
            }

            return new CommonResult<List<TicketCommentModel>>(null, dbnoteList.ResultCode, dbnoteList.Message);
        }

        public async Task<ICommonResult<int>> AddTicketCommentAsync(TicketCommentAddModel comment, int userId)
        {
            var noteId = await _ticketCommentsRepository.AddTicketCommentAsync(comment.TicketId, comment.Comment, comment.IsVisible, userId);
            return new CommonResult<int>(noteId.Payload, noteId.ResultCode);
        }

        public async Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketCommentModel ticketNote)
        {

            //var dbnote = _mapper.Map<TicketComment>(ticketNote);//PopulateNote(note);//PopulateNote(ticketNote);
            //var ticketNoteId = await _ticketNoteRepository.UpdateTicketNoteAsync(dbnote);
            //return new CommonResult<bool>(ticketNoteId.ResultCode);
            return null;
        }
        public async Task<ICommonResult<bool>> DeleteTicketNoteByIdAsync(int id)
        {
            var dbnote = await _ticketCommentsRepository.DeleteTicketNoteAsync(id);
            return new CommonResult<bool>(dbnote.ResultCode);
        }        
    }
}
