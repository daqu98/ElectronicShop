using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyEshop.Models;

public class Order
{
    #nullable disable
    [Key]
    public int OrderId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime CreateDate { get; set; }
    public bool IsFinaly { get; set; }
    [ForeignKey("UserId")]
    public Users Users { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}