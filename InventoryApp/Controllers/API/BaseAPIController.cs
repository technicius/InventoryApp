﻿using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;

namespace InventoryApp.Controllers.API
{
    /// <summary>
    /// Base API Controller
    /// </summary>
    /// 
    [EnableCors("*","*","GET,POST,DELETE,PUT")]
    public class BaseAPIController : ApiController
    {
        protected IHttpActionResult GetOkResult<T>(T result)
        {
            if (result == null)
            {
                return Ok();
            }

            return Ok(result);
        }

        protected IHttpActionResult GetInternalServerErrorResult(String result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            return InternalServerError(new Exception(result));
        }


        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}