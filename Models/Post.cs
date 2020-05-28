using BlazorJob.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazorJob.Models
{
    [Serializable]
    public class Post_
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }

        public int Author { get; set; } = 0;
        public int Parent { get; set; } = 0;

        public string Status { get; set; } = "draft";
        public string Type { get; set; } = "post";


        public static readonly string[] StatusList = { "draft", "pending", "private", "publish", "future", "trash", "auto-draft", "inherit" };

        public static readonly string[] TypeList = { "post", "page", "attachment" };

        public static readonly string defaultStatus = "draft";
        public static readonly string defaultType = "post";
    }
}

namespace BlazorJob.Models
{
    
  


    class Store
    {
        List<Func<List<Post>, List<Post>>> beforeList;
        List<Func<Post, Post>> beforeGetPostFuncs;


        List<Post> GetList()
        {
            var list = new List<Post>();

            list = list.Select(s =>
                beforeGetPostFuncs.Aggregate(s, (post, func) => { return func(post); })
            ).ToList();



            list = beforeList.Aggregate(list, (_list, func) => { return func(_list); });

            list = (from post in list
                    where post.Id > 0
                    orderby post.Title ascending
                    select post).ToList();

            list = list
                    .Where(post => post.Id > 0)
                    .OrderBy(post => post.Title)
                    .Select(post => post).ToList();

            return list;
        }

        Post Get()
        {
            Post post = new Post();

            Post updatedPost = beforeGetPostFuncs.Aggregate(post, (post, func) => { return func(post); });

            return updatedPost;
        }

        Post Save()
        {
            //before save
            //save
            //after save
            throw new NotImplementedException();
        }

        List<Post> Query(Query query)
        {
            // int z = post_status.AutoDraft.;


            throw new NotImplementedException();
        }

        void Test()
        {
            var q = Query(new Query() { parent = 0, limit = 12 });
        }

    }


    struct Query 
    {
        public int in_page;
        public int posts_per_page;
        public int sticky_posts;

        public string[] sort;
        public int[] category_in;
        public int[] category_exclude;

        public int cat;
        public string cat_name;
        public int[] cat_and;
        public int[] cat_in;
        public int[] cat_not_in;

        public int[] author_in;
        public int[] author_exlcude;

        public int parent;

        public int offset;
        public int limit;

        public DateTime dateMin;
        public DateTime dateMax;
        public DateTime date;

        public int id;
        public int id_in;
        public int id_not_in;

        public string type;
        public string status;

        public IContext[] context;

        bool ignore_sticky_posts;
        string searchText;


    }

    interface IContext
    {

    }

    interface IContextAdmin : IContext { }

    // STATE modifier page.state == admin , tech_work, 

    /*
    -DateTransfer class MergeItems 
    -emitter
    -events
    -cascade filter

    */

    /*
        ��� ������� �����, ��� ������ ������� ������/������� ���� ������������ ���. � ���������� ������ �� �������
        ���� add_action do_action?
       */


    /*

        'meta_query' => array(
            'relation' => 'AND',
            'state_clause' => array(
                'key' => 'state',
                'value' => 'Wisconsin',
            ),
            'city_clause' => array(
                'key' => 'city',
                'compare' => 'EXISTS',
            ), 
        ),
        'orderby' => array( 
            'city_clause' => 'ASC',
            'state_clause' => 'DESC',
        ),

        $args = array(
            'meta_key'     => 'color',
            'meta_value'   => 'blue',
            'meta_compare' => '!='
        );

        $args = array(
            'post_type'  => 'product',
            'meta_query' => array(
                array(
                    'key'     => 'color',
                    'value'   => 'blue',
                    'compare' => 'NOT LIKE',
                ),
            ),
        );

        'cache_results'  => false


     */

    enum post_status : int {
        Publish, // � a published post or page.
        Pending, // � post is pending review.
        Draft, // � a post in draft sta��tus.
        AutoDraft, //-draft� � a newly created post, with no content.
        Future, // � a post to publish in the future.
        Private, // � not visible to users who are not logged in.
        Inherit, // � a revision.see get_children().
        Trash, // � post is in trashbin (available since version 2.9).
        Any, // � retrieves any status except those from post statuses 
             //with �exclude_from_search� set to true (i.e.trash and auto-draft).
    }

    // $status.publish, $draft, $any, $pinned, $`

    public class WP_QueryVars
    {
        public int cat;
        public int posts_per_page;
        public string orderby;
        public string error;
        public int m;
        public int p;
        public string post_parent;
        public string subpost;
        public string subpost_id;
        public string attachment;
        public int attachment_id;
        public string name;
        public string _static;
        public string pagename;
        public int page_id;
        public string second;
        public string minute;
        public string hour;
        public int day;
        public int monthnum;
        public int year;
        public int w;
        public string category_name;
        public string tag;
        public string tag_id;
        public string author_name;
        public string feed;
        public string tb;
        public int paged;
        public string comments_popup;
        public string meta_key;
        public string meta_value;
        public string preview;
        public string s;
        public string sentence;
        public string fields;
        public int[] category__in;
        public string[] category__not_in;
        public string[] category__and;
        public string[] post__in;
        public string[] post__not_in;
        public string[] tag__in;
        public string[] tag__not_in;
        public string[] tag__and;
        public string[] tag_slug__in;
        public string[] tag_slug__and;
        public string ignore_sticky_posts;
        public string suppress_filters;
        public int cache_results;
        public int update_post_term_cache;
        public int update_post_meta_cache;
        public string post_type;
        public string nopaging;
        public int comments_per_page;
        public string no_found_rows;
        public string order;
    }
}