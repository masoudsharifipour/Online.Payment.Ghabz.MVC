using Online.Payment.Ghabz.MVC.Models;
using Online.Payment.Ghabz.MVC.RepositoryGhabz;
using Online.Payment.Ghabz.MVC.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.MVC.Service.Imp
{
    public class GenerateGhabzService : IGenerateGhabzService
    {

        private readonly IRepository _repository;

        public GenerateGhabzService()
        {
            _repository = new Repository();
        }
        public GenerateGhabzService(IRepository repository)
        {
            this._repository = repository;
        }

        public GenerateGhabzOutputDto generateGhabz(GenerateGhabzInputDto generateGhabzInputDto)
        {
            try
            {
                var output = new GenerateGhabzOutputDto();
                int ShenaseGhabz = generateGhabzInputDto.ShenaseGhabz.Length;
                int ShenasePardakht = generateGhabzInputDto.ShenasePardakht.Length;

                if (ShenaseGhabz >= 6 && ShenaseGhabz <= 13)
                {
                    if (ShenasePardakht >= 6 && ShenasePardakht <= 13)
                    {
                        string s = generateGhabzInputDto.ShenaseGhabz;
                        string price = "";
                        for (int i = ShenaseGhabz; i >= 6; i--)
                        {

                            price += s[(ShenaseGhabz - i)].ToString();

                        }
                        output.Parvande = price;

                        char n;
                        n = s[ShenaseGhabz - 2];
                        switch (n)
                        {
                            case '1':
                                output.Type = "آب";
                                break;
                            case '2':
                                output.Type = "برق";
                                break;
                            case '3':
                                output.Type = "گاز";
                                break;
                            case '4':
                                output.Type = "تلفن ثابت";
                                break;
                            case '5':
                                output.Type = "تلفن همراه";
                                break;
                            case '6':
                                output.Type = "شهرداری";
                                break;
                            default:
                                output.Type = "نامعتبر";
                                break;
                        }


                        string m = generateGhabzInputDto.ShenasePardakht;
                        string amount = "";
                        for (int i = ShenasePardakht; i >= 6; i--)
                        {

                            amount += m[(ShenasePardakht - i)].ToString();

                        }
                        output.Price = amount + "000";

                        output.ShenaseGhabz = generateGhabzInputDto.ShenaseGhabz;
                        output.ShenasePardakht = generateGhabzInputDto.ShenasePardakht;

                        this._repository.AddGhabz(new ghabzHistory
                        {
                            ShenaseGhabz = output.ShenaseGhabz,
                            ShenasePardakht = output.ShenasePardakht,
                            Price = int.Parse(output.Price),
                            Type = output.Type
                        });
                        return output;

                    }
                    else
                    {
                        throw new Exception("اطلاعات وارد شده صحیح نیست");
                    }
                }
                else
                {
                    throw new Exception("اطلاعات وارد شده صحیح نیست");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطایی رخ داده است", ex);
            }

        }

        public IQueryable<ghabzHistory> GetGenerateGhabzHistory()
        {
            return this._repository.GetGhabzHistory();
        }

        public paymentHistory Payment(int id)
        {
            //var ghabzHistory = this._repository.GetGhabzHistory().FirstOrDefault(x => x.Id == id).Id;
            var input = new paymentHistory
            {
                GhabzHistoryId = id,
                IsPayment = true,
                TrakingNumber = Guid.NewGuid().ToString("N"),
            };

            this._repository.AddPayment(input);
            return input;
        }
    }
}
