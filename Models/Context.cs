using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace UserDashboard.Models{
    public class Context:DbContext{
        public Context(DbContextOptions<Context> options):base(options){}
	    public DbSet<User> users { get; set; }
	    public DbSet<Post> posts { get; set; }
	    public DbSet<Comment> comments { get; set; }

	    public User CreateUser(RegisterVM registerVM){
	    	User user = new User(registerVM);
	    	// List<User> users = users.ToList();

	    	// if(users.Count() > 0){
	    	// 	user.admin = false;
    		// }else{
    		// 	user.admin = true;
    		// }

            this.Add(user);
            this.SaveChanges();
            return user;
	    }

	    public User Login(LoginVM loginVM){
	    	User user = users.Where(u => u.email == loginVM.email).SingleOrDefault();

	    	if(user == null){
	    		return null;
	    	}else{
	    		if(user.password == loginVM.password){
	    			return user;
	    		}else{
	    			return null;
	    		}
	    	}
	    }
    }
}
