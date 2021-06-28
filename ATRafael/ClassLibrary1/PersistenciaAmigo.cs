using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using ATRafael;


namespace ClassLibrary1 {
    public class PersistenciaAmigo : IPersistenciaAmigo {

        private string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATVitor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Amigo amigo) {
            using(SqlConnection conn = new SqlConnection(Connection)) {
                
                var sql = @"[dbo].[SaveAmigo]";
                
                conn.Execute(sql, new {
                    Nome = amigo.Nome,
                    Sobrenome = amigo.Sobrenome,
                    Aniversario = amigo.Aniversario
                
                },commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Update(Amigo amigo, int id) {
            using(SqlConnection conn = new SqlConnection(Connection)) {
                var sql = @"[dbo].[UpdateAmigo]";

                conn.Execute(sql, new {
                    Nome = amigo.Nome,
                    Sobrenome = amigo.Sobrenome,
                    Aniversario = amigo.Aniversario,
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Delete(int id) {
            using(SqlConnection conn = new SqlConnection(Connection)) {
                var sql = @"[dbo].[DeleteAmigo]";

                conn.Execute(sql, new {
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Amigo> GetAll() {
            using(SqlConnection conn = new SqlConnection(Connection)) {
                var sql = @"[dbo].[GetAll]";

                var resultado = conn.Query<Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure);

                return resultado.AsList();
            }
        }
    }
}
