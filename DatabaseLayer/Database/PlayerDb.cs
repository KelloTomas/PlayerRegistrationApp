using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Database
{
	public class PlayerDb : DbContext
	{
		public DbSet<Player> Player { get; set; }
		public DbSet<Category> Category { get; set; }
	}
}
