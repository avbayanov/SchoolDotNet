import Ajax from "./ajax";

export default {
    getContacts(searchTerm) {
        return Ajax.get("/api/Contacts/get", { term: searchTerm });
    },

    addContact(contact) {
        return Ajax.post("/api/Contacts/create", contact);
    },

    removeContact(ids) {
        return Ajax.post("/api/Contacts/remove", {ids: ids});
    }
};