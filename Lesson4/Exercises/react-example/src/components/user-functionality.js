import { React, Component } from 'react';
import {Button, TextField} from '@mui/material';

class GetUsersComponent extends Component {
    constructor(props) {
        super(props);
        this.state = { name: '', message: null, error: false };
    }
    render() {
        const error = this.state.error;
        const message = this.state.message;
        let messageToShow;
        if(error){
            messageToShow = <p>No user found</p>
        }
        else if(message !== null){
            messageToShow = <p>{this.state.message.name}, {this.state.message.age} year(s) old, from {this.state.message.address}, is {this.state.message.gender}</p>
        }
        else{
            messageToShow = <p></p>
        }

        return (
            <div>
                <div>
                    <TextField id="name" label="name" variant="filled" onChange={this.inputChanged}/>
                </div>
                <br/>
                <div>
                    <Button variant='contained' onClick={this.getUser}>Get user from backend</Button>
                </div>
                <div>
                    {messageToShow}
                </div>
            </div>
        );
    }

    inputChanged = event => {
        this.setState({ name: event.target.value });
    }

    getUser = () => {
        fetch(`https://localhost:7013/api/user/GetUserFromList?name=${this.state.name}`)
            .then(res =>
                res.json()
            )
            .then(
                (result) => {
                    this.setState({
                        message: result,
                        error: false
                    });
                    console.log(result);
                    console.log(this.state.message);
                },
                (error) => {
                    this.setState({
                        error: true
                    });
                });
    }
}

export default GetUsersComponent;