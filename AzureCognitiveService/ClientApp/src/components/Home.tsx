import * as React from 'react';
import { connect } from 'react-redux';
import SentimentAnalytics from './Sentiment';


const Home = () => (
 <SentimentAnalytics/>
);

export default connect()(Home);
