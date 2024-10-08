﻿using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("Id")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var vv = c.Categories.Find(id);
            if (vv == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vv);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c=new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("",p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c=new Context();
            var value=c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges ();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var c=new Context();
            var vv=c.Find<Category>(p.CategoryId);
            if(vv == null)
            {
                return NotFound();
            }
            else
            {
                vv.CategoryNmae = p.CategoryNmae;
                c.Update(vv);
                c.SaveChanges () ;
                return NoContent ();
            }
        }
    }
}
