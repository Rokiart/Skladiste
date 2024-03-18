
import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import OsobaService from "../../services/OsobaService";
import { RoutesNames } from "../../constants";




export default function OsobePromjeni(){

    const [osoba,setOsoba] = useState({});
    const routeParams = useParams();
    const navigate =useNavigate();
    
    

    async function dohvatiOsobu(){
        await OsobaService
        .getBySifra(routeParams.sifra)
        .then((res)=>{
            setOsoba(res.data);
          })
          .catch((e)=>{
            alert(e.poruka);
          });
    }

    useEffect(()=>{
        
        dohvatiOsobu();
    },[]);

    async function promjeniOsobu(osoba){
        const odgovor = await OsobaService.promjeni(routeParams.sifra,osoba);
        if(odgovor.ok){
          navigate(RoutesNames.OSOBE_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
            
            const osoba ={
                ime: podaci.get('ime'),
                prezime: podaci.get('prezime'),
                brojtelefona: podaci.get('brojtelefona'),
                email: podaci.get('email')
            };
                
           promjeniOsobu(osoba);    
       
    }


    return (

        <Container >
           
           <Form onSubmit={handleSubmit}>

                <Form.Group  controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.ime}
                        name="ime"
                        maxLength={50}
                        required
                    />
                </Form.Group>

                <Form.Group  controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.prezime}
                        name="prezime"
                        maxLength={50}
                        required
                    />
                </Form.Group>

                <Form.Group controlId="brojtelefona">
                    <Form.Label>Broj Telefona</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.brojTelefona}
                        name="brojtelefona"
                        maxLength={50}
                    />
                </Form.Group>

                <Form.Group controlId="email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.email}
                        name="email"
                        maxLength={20}
                    />
                </Form.Group>

                
                <Row >
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.OSOBE_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                           
                            type="submit"
                        >
                            Promjeni podatke osobe
                        </Button>
                    </Col>
                </Row>
                
           </Form>

        </Container>

    );

}