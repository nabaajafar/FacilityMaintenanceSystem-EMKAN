using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMKAN.Business.Servicess
{
   public class ReplyMessage
    {
            private readonly EMKANDbContext _db;
            public ReplyMessage(EMKANDbContext db)
            {
                _db = db;
            }
            public void AddNewReply(ReplyDto reply)
            {
            if (reply != null)
            {
                var serviceResponse = _db.Services.FirstOrDefault(x => x.ID == reply.ServiceId);
                serviceResponse.ResponseDate = DateTime.Now;

                var newReply = new Reply
                {

                    ServiceId = reply.ServiceId,
                    MessageContent = reply.MessageContent,
                    MessageTime = DateTime.Now



                };
                _db.Reply.Add(newReply);
                _db.SaveChanges();
            }
         
         
            }
        }
    }

