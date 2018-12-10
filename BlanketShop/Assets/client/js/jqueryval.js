    var pusher = new Pusher('XXX_APP_KEY', {
        cluster: 'XXX_APP_CLUSTER'
    });
var my_channel = pusher.subscribe('asp_channel');
var app = new Vue({
    el: '#app',
    data: {
        comments: [],
        comment: {
            NickName: '',
            Comment: '',
            ID: @Model.ID
        }
    },
    created: function() {
        this.get_comments();
        this.listen();
    },
    methods: {
        get_comments: function() {
            axios.get('@Url.Action("Comments", "Review", new { id = @Model.ID }, protocol: Request.Url.Scheme)')
                .then((response) => {

                    this.comments = response.data;

                });

        },
        listen: function() {
            my_channel.bind("asp_event", (data) => {
                if (data.ID == this.comment.ID) {
                    this.comments.push(data);
                }

            })
        },
        submit_comment: function() {
            axios.post('@Url.Action("Comment", "Review", new {}, protocol: Request.Url.Scheme)', this.comment)
                .then((response) => {
                    this.comment.NickName = '';
                    this.comment.Comment = '';
                    alert("Comment Submitted");

                });
        }
    }
});
