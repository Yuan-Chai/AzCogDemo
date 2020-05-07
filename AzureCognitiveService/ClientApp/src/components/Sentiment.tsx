import * as React from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap'

interface SentimentResponse {
    sentiment:string
    referrenceId:string
}

interface IProps {

}
interface IState {
    message:string,
    sentiment:string
}

class SentimentAnalytics extends React.PureComponent<IProps, IState>
{
    constructor(props:IProps){
        super(props)
        this.state = {
            message: '',
            sentiment : ''
        }
        this.handleChange = this.handleChange.bind(this)
        this.onSubmit = this.onSubmit.bind(this)
    }

    handleChange = async (event: any) =>{
        const { target }  = event
        const{ name, value } = target;
        await this.setState({[name]:value} as IState)
    }

   onSubmit = (event: any) =>
   {
       event.preventDefault()
       console.log(this.state)
       fetch('/api/sentiment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.state),
      }).then((res)=> {
          res.json().then((value: SentimentResponse) => 
          {
              console.log(value.sentiment);
              this.setState({["sentiment"]:value.sentiment})
            })
      })
   }

    public render() {
        return (
            <React.Fragment>
            <Form onSubmit={this.onSubmit}>
                <FormGroup>
                    <Label for= "sentimentInput" >Message</Label>
                    <Input type = "textarea" name = "message" id = "sentimentInput" onChange={this.handleChange}/>
                </FormGroup>
                <Button type="submit">Submit</Button>
            </Form>
            <Label>Result: {this.state.sentiment}</Label>
            </React.Fragment>
        )
    }
}

export default SentimentAnalytics