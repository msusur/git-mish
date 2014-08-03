using System.Collections.Generic;
using System;

namespace GitHookController.Models
{
    // ReSharper disable InconsistentNaming

    public class HookModel
    {
        public String EventName { get; internal set; }
        public String EventDigest { get; internal set; }
        public String EventIdentifier { get; internal set; }

        public override string ToString ()
        {
            return string.Format ("[HookModel: EventName={0}, EventDigest={1}, EventIdentifier={2}", EventName, EventDigest, EventIdentifier);
        }

        public Member member { get; set; }
        public String action { get; set; }
        public Issue issue { get; set; }
        public Sender sender { get; set; }
        public String before { get; set; }
        public Int32 number { get; set; }
        public PullRequest pull_request { get; set; }
        public Repository repository { get; set; }
        public List<Commit> commits { get; set; }
        public String after { get; set; }
        public String @ref { get; set; }
        public String ref_type { get; set; }
        public String master_branch { get; set; }
        public String description { get; set; }
        public String pusher_type { get; set; }

        public bool created { get; set; }
        public bool deleted { get; set; }
        public bool forced { get; set; }
        public string compare { get; set; }
        public Commit head_commit { get; set; }
        public Author pusher { get; set; }

        public class Committer
        {
            public string name { get; set; }
            public string email { get; set; }
            public string username { get; set; }
        }

        public class Member
        {
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Owner
        {
            public string name { get; set; }
            public string email { get; set; }
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Repository
        {
            public int id { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }
            public Owner owner { get; set; }
            public bool @private { get; set; }
            public string html_url { get; set; }
            public string description { get; set; }
            public bool fork { get; set; }
            public string url { get; set; }
            public string forks_url { get; set; }
            public string keys_url { get; set; }
            public string collaborators_url { get; set; }
            public string teams_url { get; set; }
            public string hooks_url { get; set; }
            public string issue_events_url { get; set; }
            public string events_url { get; set; }
            public string assignees_url { get; set; }
            public string branches_url { get; set; }
            public string tags_url { get; set; }
            public string blobs_url { get; set; }
            public string git_tags_url { get; set; }
            public string git_refs_url { get; set; }
            public string trees_url { get; set; }
            public string statuses_url { get; set; }
            public string languages_url { get; set; }
            public string stargazers_url { get; set; }
            public string contributors_url { get; set; }
            public string subscribers_url { get; set; }
            public string subscription_url { get; set; }
            public string commits_url { get; set; }
            public string git_commits_url { get; set; }
            public string comments_url { get; set; }
            public string issue_comment_url { get; set; }
            public string contents_url { get; set; }
            public string compare_url { get; set; }
            public string merges_url { get; set; }
            public string archive_url { get; set; }
            public string downloads_url { get; set; }
            public string issues_url { get; set; }
            public string pulls_url { get; set; }
            public string milestones_url { get; set; }
            public string notifications_url { get; set; }
            public string labels_url { get; set; }
            public string releases_url { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string pushed_at { get; set; }
            public string git_url { get; set; }
            public string ssh_url { get; set; }
            public string clone_url { get; set; }
            public string svn_url { get; set; }
            public object homepage { get; set; }
            public int size { get; set; }
            public int stargazers_count { get; set; }
            public int watchers_count { get; set; }
            public object language { get; set; }
            public bool has_issues { get; set; }
            public bool has_downloads { get; set; }
            public bool has_wiki { get; set; }
            public int forks_count { get; set; }
            public object mirror_url { get; set; }
            public int open_issues_count { get; set; }
            public int forks { get; set; }
            public int open_issues { get; set; }
            public int watchers { get; set; }
            public string default_branch { get; set; }
        }

        public class Author
        {
            public string email { get; set; }
            public string name { get; set; }
            public string username { get; set; }
        }

        public class Commit
        {
            public string id { get; set; }
            public bool distinct { get; set; }
            public string url { get; set; }
            public Author author { get; set; }
            public Committer committer { get; set; }
            public string message { get; set; }
            public string timestamp { get; set; }
            public List<object> added { get; set; }
            public List<object> removed { get; set; }
            public List<string> modified { get; set; }
        }

        public class User
        {
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Head
        {
            public string label { get; set; }
            public string @ref { get; set; }
            public string sha { get; set; }
            public User user { get; set; }
            public Repository repo { get; set; }
        }

        public class Base
        {
            public string label { get; set; }
            public string @ref { get; set; }
            public string sha { get; set; }
            public User user { get; set; }
            public Repository repo { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Html
        {
            public string href { get; set; }
        }

        public class Comments
        {
            public string href { get; set; }
        }

        public class ReviewComments
        {
            public string href { get; set; }
        }

        public class ReviewComment
        {
            public string href { get; set; }
        }

        public class Commits
        {
            public string href { get; set; }
        }

        public class Statuses
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Html html { get; set; }
            public Issue issue { get; set; }
            public Comments comments { get; set; }
            public ReviewComments review_comments { get; set; }
            public ReviewComment review_comment { get; set; }
            public Commits commits { get; set; }
            public Statuses statuses { get; set; }
        }

        public class Label
        {
            public string url { get; set; }
            public string name { get; set; }
            public string color { get; set; }
        }

        public class Issue
        {
            public string href { get; set; }
            public string url { get; set; }
            public string labels_url { get; set; }
            public string comments_url { get; set; }
            public string events_url { get; set; }
            public string html_url { get; set; }
            public int id { get; set; }
            public int number { get; set; }
            public string title { get; set; }
            public User user { get; set; }
            public List<Label> labels { get; set; }
            public string state { get; set; }
            public object assignee { get; set; }
            public object milestone { get; set; }
            public int comments { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object closed_at { get; set; }
            public string body { get; set; }
        }

        public class PullRequest
        {
            public string url { get; set; }
            public int id { get; set; }
            public string html_url { get; set; }
            public string diff_url { get; set; }
            public string patch_url { get; set; }
            public string issue_url { get; set; }
            public int number { get; set; }
            public string state { get; set; }
            public string title { get; set; }
            public User user { get; set; }
            public string body { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public object closed_at { get; set; }
            public object merged_at { get; set; }
            public object merge_commit_sha { get; set; }
            public object assignee { get; set; }
            public object milestone { get; set; }
            public string commits_url { get; set; }
            public string review_comments_url { get; set; }
            public string review_comment_url { get; set; }
            public string comments_url { get; set; }
            public string statuses_url { get; set; }
            public Head head { get; set; }
            public Base @base { get; set; }
            public Links _links { get; set; }
            public bool merged { get; set; }
            public object mergeable { get; set; }
            public string mergeable_state { get; set; }
            public object merged_by { get; set; }
            public int comments { get; set; }
            public int review_comments { get; set; }
            public int commits { get; set; }
            public int additions { get; set; }
            public int deletions { get; set; }
            public int changed_files { get; set; }
        }

        public class Sender
        {
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

    }
}