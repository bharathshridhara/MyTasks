using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUser : IdentityUser
{
    /* identity field from database */
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    public bool Internal { get; set; }

    public string UserFullName { get; set; }

    public string UserEmail { get; set; }

    public ApplicationUser()
        : base()
    {
        Internal = false;
    }

    public ApplicationUser(string userName)
        : base(userName)
    {
        Internal = false;
    }

}