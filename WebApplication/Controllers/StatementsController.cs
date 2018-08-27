using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.DTO;
using AutoMapper;
using WebApplication.ViewModels;
using WebApplication.Core;
using WebApplication.Persistence;

namespace WebApplication.Controllers
{
    [Authorize]
    [RoutePrefix("api/statements")]
    public class StatementsController : ApiController
    {
        public IUnitOfWork _unitOfWork;

        public StatementsController() => _unitOfWork = new UnitOfWork();



        [Route("{id:min(1)}")]
        public IHttpActionResult Get(int id)
        {
            var Statement = _unitOfWork.StatementRepository.GetById(id);

            _unitOfWork.Dispose();

            if (Statement == null)
                return NotFound();

            StatementDTO Data = Mapper.Map<Statement, StatementDTO>(Statement);

            return Ok(Data);
        }




        [HttpPost]
        [Route("{PageNumber:min(1)}/{ItemsPerPage:min(1)}")]
        public IHttpActionResult GetAll(int PageNumber, int ItemsPerPage, [FromBody]StatementFilter Filters)
        {
            var Statements = _unitOfWork.StatementRepository.GetAll(PageNumber, ItemsPerPage, Filters);

            IEnumerable<StatementDTO> Data = Mapper.Map<IEnumerable<Statement>,IEnumerable<StatementDTO>>(Statements);
            int ItemsNumber = _unitOfWork.StatementRepository.Count(Filters);

            _unitOfWork.Dispose();

            return Ok(new StatementsViewModel { ItemsNumber = ItemsNumber, Data = Data });
        }
    }
}
