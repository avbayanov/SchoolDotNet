import "bootstrap/dist/css/bootstrap.css";

import Vue from "vue";
import "bootstrap";

import PhonebookComponent from "./components/Phonebook.vue";

new Vue({
    el: "#app",
    components: {
        "phonebook": PhonebookComponent
    }
});
