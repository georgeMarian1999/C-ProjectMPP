using System;
using System.Collections.Generic;
using System.Numerics;
using Problem11.Model;

namespace Problem11.Repositories
{
    public interface ICursaRepository : ICrudRepository<int, Cursa>
    {
        int findIdByCapacitate(int capacitate);
        List<DTOBJCursa> GroupByCapacitate();
    }
}
