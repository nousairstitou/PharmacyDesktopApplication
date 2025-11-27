using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Mapper {

    public class PaymentMapper : IEntityMapper<Payment> , IViewMapper<PaymentViewModel> {

        public PaymentViewModel MapToView(SqlDataReader Reader) {

            return new PaymentViewModel {

                PaymentId = Reader.GetInt32(Reader.GetOrdinal("PaymentId")),
                AmountPaid = Reader.GetDecimal(Reader.GetOrdinal("AmountPaid")),
                PaymentDate = Reader.GetDateTime(Reader.GetOrdinal("PaymentDate")),
                MethodName = Reader.GetString(Reader.GetOrdinal("MethodName")),
                PaymentStatus = Reader.GetString(Reader.GetOrdinal("PaymentStatus")),
                CreatedAt = Reader.GetDateTime(Reader.GetOrdinal("CreatedAt"))
            };
        }

        public Payment Map(SqlDataReader Reader) {

            return new Payment {

                PaymentId = Reader.GetInt32(Reader.GetOrdinal("PaymentId")),
                SaleId = Reader.GetInt32(Reader.GetOrdinal("SaleId")),
                PaymentMethodId = Reader.GetInt32(Reader.GetOrdinal("PaymentMethodId")),
                PaymentDate = Reader.GetDateTime(Reader.GetOrdinal("PaymentDate")),
                AmountPaid = Reader.GetDecimal(Reader.GetOrdinal("TotalAmount")),
                Status = Reader.GetByte(Reader.GetOrdinal("Status"))
            };
        }
    }
}