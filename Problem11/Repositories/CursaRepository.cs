using System;
using System.Data;
using log4net;
using Problem11.ConnectionUtils;
using Problem11.Model;

namespace Problem11.Repositories
{
    public class CursaRepository : ICursaRepository
    {
        public static readonly ILog logger = LogManager.GetLogger("CursaRepository");


        public CursaRepository()
        {
            logger.Info("Se creeaza Repository de curse");
        }

        public void delete(int id)
        {
            logger.InfoFormat("Se sterge cursa cu id-ul {0}", id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "delete from Cursa where idCursa=@id";

                IDbDataParameter paramId = com.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                com.Parameters.Add(paramId);
                var result = com.ExecuteNonQuery();
                if (result == 0)
                {
                    logger.Info("Eroare incercand sa se stearga cursa cu id-ul");
                    throw new Exception("Eroare la stergere");
                }
                logger.InfoFormat("S-a sters cursa cu id-ul {0}", id);
            }
        }

        public Cursa findOne(int id)
        {
            logger.InfoFormat("Se cauta cursa cu id-ul {0}", id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "select idCursa,capacitate from Cursa where idCursa=@id";
                IDbDataParameter paramId = com.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                com.Parameters.Add(paramId);

                using (var Data = com.ExecuteReader())
                {
                    if (Data.Read())
                    {
                        int idCursa = Data.GetInt32(0);
                        int capacitate = Data.GetInt32(1);
                        
                        Cursa C = new Cursa(idCursa,capacitate);
                        logger.InfoFormat("S-a gasit cursa cu id-ul {0}", C.Id);
                        return C;
                    }
                }
            }
            logger.InfoFormat("Nu s a gasit Cursa cu id ul {0}", id);
            return null;
        }

        public void save(Cursa entity)
        {
            logger.InfoFormat("Se salveaza cursa cu id-il {0}", entity.Id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "insert into Cursa values (@idCursa,@capacitate)";

                IDbDataParameter paramIdCursa = com.CreateParameter();
                paramIdCursa.ParameterName = "@idCursa";
                paramIdCursa.Value = entity.Id;
                com.Parameters.Add(paramIdCursa);

                IDbDataParameter paramCapacitate = com.CreateParameter();
                paramCapacitate.ParameterName = "@capacitate";
                paramCapacitate.Value = entity.Capacitate;
                com.Parameters.Add(paramCapacitate);

                
                var result = com.ExecuteNonQuery();
                if (result == 0)
                {
                    logger.Info("Error while adding");
                    throw new Exception("Nici o cursa adaugata!");
                }

            }
            logger.InfoFormat("A fost adaugata cursa cu id-ul {0}", entity.Id);
        }


    }
}
