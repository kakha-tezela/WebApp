using System.Collections.Generic;
using WebApplication.DTO;

namespace WebApplication.ViewModels
{
    public class StatementsViewModel
    {
        public int ItemsNumber { get; set; }
        public IEnumerable<StatementDTO> Data { get; set; }
    }
}