using System;
using System.Collections.Generic;

namespace cadastroProdutos
{
    public interface IRepositorio<T>
    {
        List<T> FindAll();
        T Find(int id);
        void Create(T entidade);
        void Destroy(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}