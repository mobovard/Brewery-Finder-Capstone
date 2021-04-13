import axios from 'axios';

export default {
    getBreweries() {
        return axios.get('/breweries');
    },
    getBrewery(id){
        return axios.get(`/breweries/${id}`);
    },
    addBrewery(brewery) {
        return axios.post('/breweries', brewery);
    },
    updateBrewery(brewery) {
        return axios.put(`/breweries`, brewery);
    },


    getBeer(beerId) {
        return axios.get(`/beers/${beerId}`);
    },
    getBeers(breweryId) {
        return axios.get(`/breweries/${breweryId}/beers`);
    },
    addBeer(beer) {
        return axios.post(`/beers`, beer);
    },
    updateBeer(beer) {
        return axios.put('/beers', beer);
    },


    getReviews(beerId) {
        return axios.get(`/ratings/${beerId}`);
    },
    addReview(review) {
        return axios.post('/ratings', review);
    },

    getUsers() {
        return axios.get('/users');
    },
}