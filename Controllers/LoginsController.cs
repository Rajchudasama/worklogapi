﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using worklogapi.Models;

namespace worklogapi.Controllers
{
    public class LoginsController : ApiController
    {
        private work_logEntities db = new work_logEntities();

        

        // GET: api/Logins
        [Route("api/Logins")]
        public IQueryable<Login> GetLogins()
        {
            return db.Logins;
        }

        // GET: api/Logins/5
        //[ResponseType(typeof(Login))]
        //public IHttpActionResult GetLogin(int id)
        //{
        //    Login login = db.Logins.Find(id);
        //    if (login == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(login);
        //}

        // PUT: api/Logins/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutLogin(int id, Login login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != login.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(login).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoginExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        [HttpPost]
        [Route("api/auth")]
        public IHttpActionResult Auth(Login login)
        {
            var logins = db.Logins.Where(e => e.email == login.email && e.password == login.password).SingleOrDefault();
            if (logins != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
            
        }

        // POST: api/Logins
        [ResponseType(typeof(Login))]
        [Route("api/register")]
        public IHttpActionResult PostLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Logins.Add(login);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(Login))]
        [Route("api/Deleteuser")]
        public IHttpActionResult DeleteLogin(int id)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            db.Logins.Remove(login);
            db.SaveChanges();

            return Ok(login);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool LoginExists(int id)
        {
            return db.Logins.Count(e => e.Id == id) > 0;
        }
    }
}