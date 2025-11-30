using Azure.Core;
using Business.Abstract.Common;
using Business.DTOs.Request.Sale;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.SaleMapper {

    public sealed class CreateSaleMapperToEntity : IEntityMapper<CreateSaleRequest, TransactionSale> {

        public TransactionSale Map(CreateSaleRequest request) {

            return new TransactionSale {

                Sale = new Sale {

                    Note = request.Note
                },

                Payment = new Payment {

                    PaymentMethodId = request.PaymentMethodId,
                    AmountPaid = request.AmountPaid,
                },

                Billing = new Billing {

                    Note = request.BillingNote,
                    CreatedBy = request.CreatedBy,
                },

                SaleItems = request.SaleItems.Select(item => new SaleItem {

                    MedicineId = item.MedicineId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice

                }).ToList()
            };
        }
    }
}