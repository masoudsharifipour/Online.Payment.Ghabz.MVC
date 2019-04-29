using Online.Payment.Ghabz.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.MVC.RepositoryGhabz
{
    public interface IRepository
    {
        void AddGhabz(ghabzHistory AddGhazHistory);
        IQueryable<ghabzHistory> GetGhabzHistory();

        void Commit();
        void AddPayment(paymentHistory paymentHistory);
    }
}
