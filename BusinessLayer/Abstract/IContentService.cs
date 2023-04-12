using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter();
        List<Content> GetListByHeadingID(int id);
        void ContentAddBL(Content content);
        Content GetByID(int id);
        void ContentyDelete(Content content);
        void ContentUpdate(Content content);
    }
}
