using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Cadastro_Series_.Net.Interfaces
{
    public interface IRepositorio<T>
    {
       List<T> Lista();
       T RetornaPorId (int id);
       void Insere(T entidade);
       void Exclui(int id);
       void Atualiza(int id, T entidade);
       int ProximoId(); 
    }
}