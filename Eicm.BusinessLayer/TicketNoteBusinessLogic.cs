using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class TicketNoteBusinessLogic : ITicketNoteBusinessLogic
    {
        private readonly ITicketCommentsRepository _ticketCommentsRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TicketNoteBusinessLogic(ITicketCommentsRepository ticketCommentsRepository)
        {
            _ticketCommentsRepository = ticketCommentsRepository;
        }
        public async Task<ICommonResult<TicketNoteModel>> GetTicketNoteByIdAsync(int id)
        {           
            var dbnote =  await _ticketCommentsRepository.GetTicketNoteByIdAsync(id);
            if (dbnote.ResultCode && dbnote.Payload == null)
            {
                _logger.Info("No note returned for id: " + id);
                return new CommonResult<TicketNoteModel>(null, dbnote.ResultCode);
            }
            if (!dbnote.ResultCode)
            {
                _logger.Info("getTicketNoteByIdAsync returned failed from repo");
                return new CommonResult<TicketNoteModel>(null, dbnote.ResultCode, dbnote.Message);
            }
            _logger.Info("Note retrieved");
            return new CommonResult<TicketNoteModel>(new TicketNoteModel(dbnote.Payload), dbnote.ResultCode); 
        }
        
        public async Task<ICommonResult<List<TicketNoteModel>>> GetTicketNotesAsync()
        {
            var dbnoteList = await _ticketCommentsRepository.GetTicketNotesAsync();       

            if (dbnoteList.ResultCode)
            {
                var noteList = dbnoteList.Payload.Select(note => new TicketNoteModel(note)).ToList();
                return new CommonResult<List<TicketNoteModel>>(noteList, dbnoteList.ResultCode);
            }

            return new CommonResult<List<TicketNoteModel>>(null, dbnoteList.ResultCode, dbnoteList.Message);
        }

        public async Task<ICommonResult<int>> AddTicketNoteAsync(TicketNoteModel note)
        {
            //var noteToAdd = _mapper.Map<TicketComment>(note);//PopulateNote(note);

            //noteToAdd.EnteredDate = DateTime.Now;
            //noteToAdd.ModifiedDate = DateTime.Now;
            //noteToAdd.IsActive = true; //TODO change this property to IsInactive or IsDeleted so you do not have to set to true each time

            //var noteId = await _ticketNoteRepository.AddTicketNoteAsync(noteToAdd);
            //return new CommonResult<int>(noteId.Payload, noteId.ResultCode);
            return null;
        }

        public async Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketNoteModel ticketNote)
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
