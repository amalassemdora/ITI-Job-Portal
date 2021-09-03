using Itians.BL.Interface;
using Itians.Controllers;
using Itians.Controllers.HelperClasses;
using Itians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.BL.Repository
{
	public class GroupRep: IGroupRep
    {
        itiansContext db;
		public GroupRep(itiansContext db)
		{
            this.db=db;
		}
       

        public IQueryable<GroupModel> Get()
        {
            var data = db.Groups.Select(a => new GroupModel { GroupId = a.GroupId, GroupName=a.GroupName });
            return data;
        }

        public GroupModel GetById(int id)
        {
            var data = db.Groups.Where(a => a.GroupId == id)
                                    .Select(a => new GroupModel { GroupId = a.GroupId, GroupName = a.GroupName, GroupDesc = a.GroupDesc })
                                    .FirstOrDefault();
			return data;
        }

        public void Add(GroupModel G)
        {
            // Mapping
            Group d = new Group();
            d.GroupName = G.GroupName;
            d.GroupDesc = G.GroupDesc;
            d.GroupAdmins = G.GroupAdmins;
            db.Groups.Add(d);
            db.SaveChanges();
        }

        public void Edit(GroupModel groupModel)
        {
            var OldData = db.Groups.Find(groupModel.GroupId);

            OldData.GroupName = groupModel.GroupName;
            OldData.GroupDesc = groupModel.GroupDesc;
            OldData.GroupAdmins = groupModel.GroupAdmins;


            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Groups.Find(id);
            db.Groups.Remove(DeletedObject);
            db.SaveChanges();
        }
    }


}