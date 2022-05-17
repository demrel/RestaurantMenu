import  ReactNode  from 'react';
import {
  Box,
  Flex,
  HStack,
  Link,
  useColorModeValue,
} from '@chakra-ui/react';




export const Header =()=> {

  return (
      <Box bg={useColorModeValue('gray.100', 'gray.900')} px={4}>
        <Flex h={16} alignItems={'center'} justifyContent={'space-between'}>
          <HStack spacing={8} alignItems={'center'}>
            <HStack
              as={'nav'}
              spacing={4}
              display={{ base: 'none', md: 'flex' }}>
           <Link px={2} py={1} rounded={'md'}_hover={{textDecoration: 'none', bg: useColorModeValue('gray.200', 'gray.700'), }}  href={'/'}> Home </Link>
           <Link px={2} py={1} rounded={'md'}_hover={{textDecoration: 'none', bg: useColorModeValue('gray.200', 'gray.700'), }}  href={'/category'}> Category </Link>
           <Link px={2} py={1} rounded={'md'}_hover={{textDecoration: 'none', bg: useColorModeValue('gray.200', 'gray.700'), }}  href={'/product'}> Products </Link>

            </HStack>
          </HStack>
          <Flex alignItems={'center'}>
          </Flex>
        </Flex>

    
      </Box>
  );
}