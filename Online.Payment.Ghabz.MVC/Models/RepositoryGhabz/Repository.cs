using Online.Payment.Ghabz.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.MVC.RepositoryGhabz
{
    public class Repository : IRepository
    {
        Models.OnlinePaymentGhabzEntities _db = new Models.OnlinePaymentGhabzEntities();

        public Repository()
        {

        }

        public void AddGhabz(ghabzHistory AddGhazHistory)
        {
            this._db.ghabzHistories.Add(AddGhazHistory);
            this.Commit();
        }

        public void AddPayment(paymentHistory paymentHistory)
        {
            this._db.paymentHistories.Add(paymentHistory);
            this.Commit();
        }

        public void Commit()
        {
            this._db.SaveChanges();
        }

        public IQueryable<ghabzHistory> GetGhabzHistory()
        {
            return this._db.ghabzHistories.AsQueryable();
        }

    }
}
