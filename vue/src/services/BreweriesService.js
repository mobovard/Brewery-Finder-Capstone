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
    addBrewery(brewery) {
        console.log(brewery);
        return axios.post('/breweries', brewery);
    },
    addBeer(beer) {
        return axios.post(`/beers`, beer);
    },
}