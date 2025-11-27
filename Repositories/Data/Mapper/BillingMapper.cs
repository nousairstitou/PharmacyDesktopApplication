using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using Repositories.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Mapper {

    public class BillingMapper : IEntityMapper<Billing> , IViewMapper<BillingViewModel> {

        public BillingViewModel MapToView(SqlDataReader Reader) {

            return new BillingViewModel {

                BillingId = Reader.GetInt32(Reader.GetOrdinal("BillingId")),
                AmountPaid = Reader.GetDecimal(Reader.GetOrdinal("AmountPaid")),
                MethodName = Reader.GetString(Reader.GetOrdinal("MethodName")),
                BillingDate = Reader.GetDateTime(Reader.GetOrdinal("BillingDate")),
                UserName = Reader.GetString(Reader.GetOrdinal("UserName")),
                BillingStatus = Reader.GetString(Reader.GetOrdinal("BillingStatus")),
                Note = Reader.IsDBNull(Reader.GetOrdinal("Note")) ? null : Reader.GetString(Reader.GetOrdinal("Note")),
                CreatedAt = Reader.GetDateTime(Reader.GetOrdinal("CreatedAt")),
            };
        }

        public Billing Map(SqlDataReader Reader) {

            return new Billing {

                BillingId = Reader.GetInt32(Reader.GetOrdinal("BillingId")),
                SaleId = Reader.GetInt32(Reader.GetOrdinal("SaleId")),
                BillingDate = Reader.GetDateTime(Reader.GetOrdinal("BillingDate")),
                CreatedBy = Reader.GetInt32(Reader.GetOrdinal("CreatedBy")),
                Note = Reader.IsDBNull(Reader.GetOrdinal("Note")) ? null : Reader.GetString(Reader.GetOrdinal("Note"))
            };
        }
    }
}