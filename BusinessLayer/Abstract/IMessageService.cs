using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p); 
        List<Message> GetAllUnRead();
        List<Message> IsDraft();
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        void SaveDraftAdd(Message message);


    }
}
