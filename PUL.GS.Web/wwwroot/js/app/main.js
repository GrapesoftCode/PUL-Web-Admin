// Configure controls for each module
var PulAdmin = {
    Controls: {
        Book: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        },
        Combo: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        },
        Drink: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        },
        Food: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        },
        Promotion: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        },
        Table: {
            Grid: function (element, options) {
                if (typeof element != 'object') {
                    this.grid = document.getElementById(element);
                } else {
                    this.grid = element;
                }
            }
        }
    }
};