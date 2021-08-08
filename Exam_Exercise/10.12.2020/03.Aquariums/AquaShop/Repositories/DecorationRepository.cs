using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> collectionDecorations;
        

        public DecorationRepository()
        {
            collectionDecorations = new List<IDecoration>();
            Models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models { get; private set; }
        public void Add(IDecoration model)
        {
            collectionDecorations.Add(model);
            Models = collectionDecorations;
        }

        public bool Remove(IDecoration model)
        {
            if (Models.Contains(model))
            {
                collectionDecorations.Remove(model);

                Models = collectionDecorations;

                return true;
            }

            return false;
        }

        public IDecoration FindByType(string type)
        {
            return Models.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}
