using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanK.Persintence.Interface
{
    public interface IEntityDisplayModel<TEntity, TKey>
    {
        TKey Id { get; set; }
        void Import(TEntity entity);
    }
}
