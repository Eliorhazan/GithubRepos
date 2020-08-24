using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubRepos.Models
{
    public class RepositoryModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        
    }
    public class RepositoriesViewModel
    {
        public List<RepositoryModel> Repositories { get ; set ; }
    }
}
