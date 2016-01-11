using System;
using System.Collections.Generic;
using System.Transactions;

namespace BLL
{
    public class AdminBs : BaseBs
    {
        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var url = urlBs.GetById(item);
                        url.IsApproved = Status;
                        urlBs.Update(url);
                    }

                    trans.Complete();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}