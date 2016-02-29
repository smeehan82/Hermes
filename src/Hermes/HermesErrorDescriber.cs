using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes
{
    public class HermesErrorDescriber
    {
        public virtual HermesError DefaultError()
        {
            return new HermesError
            {
                Code = nameof(DefaultError),
                Description = "This is a Hermes Default Error"
            };
        }

        public virtual HermesError ConcurrencyFailure()
        {
            return new HermesError
            {
                Code = nameof(ConcurrencyFailure),
                Description = "Optimistic concurrency failure, object has been modified."
            };
        }

        public virtual HermesError TitleNotSet()
        {
            return new HermesError
            {
                Code = nameof(TitleNotSet),
                Description = "The title is not set."
            };
        }

        public virtual HermesError BlogPostDoesNotHaveBlog()
        {
            return new HermesError
            {
                Code = nameof(BlogPostDoesNotHaveBlog),
                Description = "The blog post must be assigned to a blog."
            };
        }
    }
}
