import axios from 'axios';

export default {
    getBreweries() {
        return axios.get('/breweries');
    },
    getBrewery(id){
        return axios.get(`/breweries/${id}`);
    },
    getBeers(breweryId) {
        return axios.get(`/breweries/${breweryId}/beers`);
    },
    getBeer(beerId) {
        return axios.get(`/beers/${beerId}`);
    },
    addBrewery(brewery) {
        return axios.post('/breweries', brewery);
    },
    updateBrewery(brewery) {
        return axios.put(`/breweries`, brewery);
    },
    addBeer(beer) {
        return axios.post(`/beers`, beer);
    },
    updateBeer(beer) {
        return axios.put('/beers', beer)
    }
}