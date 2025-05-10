using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Enums
{
    public enum Status
    {
        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Completed")]
        Completed
    }
}
