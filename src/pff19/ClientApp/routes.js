import Impressum from 'components/Impressum';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';
import FAQ from 'components/faq/FAQ';
import Organisation from 'components/Organisation';
import Helfer from 'components/helper/Helfer';
import NewsOverview from 'components/news/NewsOverview';
import News from 'components/news/News';
import Error404 from 'components/partials/404.vue';
import Contact from 'components/faq/Kontakt';


export const routes = [
    { name: 'home', path: '/', component: HomePage, display: 'Home', important: true},
    { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren', important: false},
    { name: 'faq', path: '/faq', component: FAQ, display: 'FAQ', important: false},
    { name: 'organisation', path: '/organisation', component: Organisation, display: 'Organisation', important: true},
    { name: 'helper', path: '/helfer', component: Helfer, display: 'Helfer', important: true},


    { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum'},
    { name: 'news_overview', path: '/news', component: NewsOverview, display: 'NewsOverview'},
    { name: 'news', path: '/news/:id', component: News, display: 'News'},
    { name: 'contact', path: '/contact', component: Contact, display: 'Kontakt', important: true},



    { name: '404', path: '/*', component: Error404, display: '404'}
];