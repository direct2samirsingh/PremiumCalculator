import { isNumeric } from 'jquery';
import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import { FormErrors } from './FormErrors';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            age: 10, dateOfBirth: new Date(), sumInsured: 5000, occupationId: 0, monthlyPremium: 0,
            occupations: [],
            formErrors: { age: '', dateOfBirth: '', sumInsured: '', occupationId: '' },
            ageValid: false, dateOfBirthValid: false, sumInsuredValid: false, occupationIdValid: false, formValid: false
        };
        this.calculate = this.calculate.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    handleChange = (field) => (event) => {
        let value = event.target.value;
        let name = field;

        this.setState({ [name]: value });
    }

    handleSubmit(event) {
        this.populateData();
        event.preventDefault();
    }

    componentDidMount() {
        let result = [];
        fetch('api/Occupation')
            .then(response => {
                return response.json();
            }).then(data => {
                this.setState({
                    occupations: data,
                });
            });
    }

    render() {
        let result = this.state.loading
            ? <p><em>Calculating, please wait...</em></p>
            : this.state.monthlyPremium;

        let occupations = this.state.occupations || [];
        let optionItems = occupations.map((occupation) =>
            <option key={occupation.id}>{occupation.name}</option>
        );

        let formValid = this.state.formValid;

        return (
            <div>
                <h1>Enter details below:</h1>
                <FormErrors formErrors={this.state.formErrors} />
                <form onSubmit={this.handleSubmit}>
                    <table>
                        <tbody>
                            <tr>
                                <td>Age</td>
                                <td><input required type="text" value={this.state.age} onChange={this.handleChange('age')} /></td>
                            </tr>
                            <tr>
                                <td>Date of Birth</td>
                                <td><input required type="date" value={this.state.dateOfBirth} onChange={this.handleChange('dateOfBirth')} /></td>
                            </tr>
                            <tr>
                                <td>Sum Insured</td>
                                <td><input required type="text" value={this.state.sumInsured} onChange={this.handleChange('sumInsured')} /></td>
                            </tr>
                            <tr>
                                <td>Occupation</td>
                                <td>
                                    <select required value={this.state.occupationId} onChange={this.handleChange('occupationId')}>   
                                        {optionItems}
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>Monthly Premium</td>
                                <td>{result}</td>
                            </tr>
                        </tbody>
                    </table>
                </form>

                <button className="btn btn-primary" onClick={this.calculate}>Calculate</button>
            </div>
        );
    }


    async calculate() {

        

        const token = await authService.getAccessToken();
        const requestObject = {
            age: this.state.age,
            dateOfBirth: this.state.dateOfBirth,
            sumInsured: this.state.sumInsured,
            occupationId: this.occupationId
        };

        fetch('api/Premium', {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(requestObject)
        })
        .then(response => response.json())
        .then((data) => {
            this.setState({ monthlyPremium: data.monthlyPremium, loading: false });
        })
        .catch(error => this.setState({
            isLoading: false,
            message: 'Error occured while processing ' + error
        }));
    }

}
