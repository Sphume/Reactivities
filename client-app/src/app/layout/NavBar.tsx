import { Button, Container, Menu } from "semantic-ui-react";

interface Props {
    openForm: () => void; // takes no parameters because it creates activity
}

export default function NavBar({openForm}: Props) {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}}/>
                    Reactivites
                </Menu.Item>

                <Menu.Item name='Activites'/>

                <Menu.Item>
                    <Button onClick={openForm} positive content='Create Activity'/>
                </Menu.Item>
            </Container>
        </Menu>
    )
}