namespace StickyNotes.Controllers {

    export class HomeController {

        public stickies;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/stickies')
                .then((results) => {
                    this.stickies = results.data;
                });
        }

        public postSticky(sticky) {
            this.$http.post('/api/stickies', sticky)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });


        }


        public deleteSticky(sticky) {
            this.$http.delete(`/api/stickies/${sticky.id}`)
                .then((results) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });
        }

    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
