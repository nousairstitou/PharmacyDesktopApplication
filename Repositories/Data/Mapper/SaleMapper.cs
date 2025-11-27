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

    public class SaleMapper : IEntityMapper<Sale> , IViewMapper<SaleViewModel> {

        public SaleViewModel MapToView(SqlDataReader Reader) {

            return new SaleViewModel {

                SaleId = Reader.GetInt32(Reader.GetOrdinal("SaleId")),
                Name = Reader.GetString(Reader.GetOrdinal("Name")),
                SaleDate = Reader.GetDateTime(Reader.GetOrdinal("SaleDate")),
                TotalAmount = Reader.GetDecimal(Reader.GetOrdinal("TotalAmount")),
                SaleStatus = Reader.GetString(Reader.GetOrdinal("SaleStatus")),
                Note = Reader.IsDBNull(Reader.GetOrdinal("Note")) ? null : Reader.GetString(Reader.GetOrdinal("Note")),
                CreatedDate = DateOnly.FromDateTime(Reader.GetDateTime(Reader.GetOrdinal("CreatedDate")))
            };
        }

        public Sale Map(SqlDataReader Reader) { 
        
            return new Sale {

                SaleId = Reader.GetInt32(Reader.GetOrdinal("SaleId")),
                CustomerId = Reader.GetInt32(Reader.GetOrdinal("CustomerId")),
                SaleDate = Reader.GetDateTime(Reader.GetOrdinal("SaleDate")),
                Status = Reader.GetByte(Reader.GetOrdinal("Status")),
                Note = Reader.IsDBNull(Reader.GetOrdinal("Note")) ? null : Reader.GetString(Reader.GetOrdinal("Note")),
                TotalAmount = Reader.GetDecimal(Reader.GetOrdinal("TotalAmount"))
            };
        }
    }
}