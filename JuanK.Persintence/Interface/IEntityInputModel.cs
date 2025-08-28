using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Interface
{
    public interface IEntityInputModel<TEntity, TKey> : IEntityDisplayModel<TEntity, TKey>    {
        
        TEntity Export();       
        void Merge(TEntity entity);
    }
}
