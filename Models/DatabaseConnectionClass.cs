using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Phephi.Models {
    public class DatabaseConnectionClass : DbContext {
        public DatabaseConnectionClass(): base("SurveyDatabase") {

        }

        public DbSet<PersonModel> People { get; set; }
    }
}