using Online.Payment.Ghabz.MVC.Models;
using Online.Payment.Ghabz.MVC.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.MVC.Service
{
    public interface IGenerateGhabzService
    {
        GenerateGhabzOutputDto generateGhabz(GenerateGhabzInputDto generateGhabzInputDto);
        IQueryable<ghabzHistory> GetGenerateGhabzHistory();
        paymentHistory Payment(int id);
    }
}
