using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Hermes.Mvc;

namespace Hermes.Content.Blogs
{
    [Route("api/content/blogs")]
    public class BlogController : ContentController<Blog, Guid>
    {
        #region Contructor

        public BlogController(BlogManager manager) : base(manager)
        {
            _manager = manager;
        }

        new protected BlogManager _manager;

        #endregion

        //POST
        #region create

        [HttpPost]
        [Route("create-title")]
        public virtual async Task<IActionResult> Create([FromQuery]string title)
        {
            var blog = new Blog();

            blog.Title = title;
            blog.DateCreated = DateTimeOffset.Now;
            blog.DateModified = DateTimeOffset.Now;
            blog.DatePublished = DateTimeOffset.Now;

            var result = await _manager.AddAsync(blog);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //POST BlogPost
        #region create post by title

        [HttpPost]
        [Route("post/create-title")]
        public virtual async Task<IActionResult> CreatePost(string blogSlug, string title)
        {
            var blog = await _manager.FindBySlugAsync(blogSlug);
            var blogPost = new BlogPost();

            blogPost.Blog = blog;
            blogPost.BlogId = blog.Id;
            blogPost.Content = "";
            blogPost.Title = title;

            var result = await _manager.AddPostAsync(blogPost);

            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }

        }

        #endregion

        //GET BlogPost
        #region read post list

        [HttpGet]
        [Route("posts")]
        public virtual async Task<IActionResult> ListPosts()
        {
            var blogPosts = _manager.BlogPosts;
            return new ObjectResult(blogPosts);
        }

        #endregion

        //GET
        #region read post single by slug

        [HttpGet]
        [Route("single")]
        public virtual async Task<IActionResult> FindPostBySlug([FromQuery]string slug)
        {
            var blogPost = await _manager.FindPostBySlugAsync(slug);
            return new ObjectResult(blogPost);
        }

        #endregion

        //GET BlogPost
        #region read post single by id

        [HttpGet]
        [Route("post/single-id")]
        public virtual async Task<IActionResult> FindPostById(Guid id)
        {
            var blogPost = await _manager.FindPostByIdAsync(id);
            return new ObjectResult(blogPost);
        }

        #endregion

        //POST BlogPost
        #region update post

        [HttpPost]
        [Route("post/update")]
        public virtual async Task<IActionResult> UpdatePost(BlogPost blogPost)
        {
            var result = await _manager.UpdatePostAsync(blogPost);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //POST BlogPost
        #region delete post

        [HttpPost]
        [Route("post/delete")]
        public virtual async Task<IActionResult> DeletePost(BlogPost blogPost)
        {
            var result = await _manager.DeletePostAsync(blogPost);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //POST BlogPost
        #region delete post by id

        [HttpPost]
        [Route("post/delete-id")]
        public virtual async Task<IActionResult> DeletePostById([FromQuery]Guid id)
        {
            var result = await _manager.DeletePostByIdAsync(id);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion
    }
}
